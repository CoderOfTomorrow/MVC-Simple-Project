using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entites.User;
using eUseControl.Domain.Entites.Images;
using eUseControl.Helpers;
using System.Web;
using eUseControl.Domain.Entites.Topics;
using System.Collections.Generic;

namespace eUseControl.BusinessLogic.Core
{
    public class ApiUser
    {
        internal URegisterResp UserRegisterAction(URegisterData data)
        {
            UDbTable new_user = new UDbTable();

            using (var todo = new UserContext())
            {
                new_user.Username = data.Username;
                new_user.Password = LoginHelper.HashGen(data.Password);
                new_user.Email = data.Email;

                todo.Users.Add(new_user);
                todo.SaveChanges();
            }
            return new URegisterResp();
        }

        internal ULoginResp UserLoginAction(ULoginData data)
        {
            UDbTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                /*using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }*/

                return new ULoginResp { Status = true };
            }
            else
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                /*using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }*/

                return new ULoginResp { Status = true };
            }
        }

        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDbTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;
            Mapper.Initialize(cfg => cfg.CreateMap<UDbTable, UserMinimal>());
            var userminimal = Mapper.Map<UserMinimal>(curentUser);

            return userminimal;
        }

        internal CategoryResp AddCategoryAction(CategoryData category)
        {
            Forum new_category = new Forum();
            using (var todo = new ForumContext())
            {
                new_category.Title = category.Title;
                todo.Forum.Add(new_category);
                todo.SaveChanges();
            }

            return new CategoryResp();
        }

        internal TopicResp AddTopicAction(TopicData topic, int id)
        {
            using (var db = new ForumContext())
            {
                Forum category;
                category = (from e in db.Forum where e.CategoryID == id select e).FirstOrDefault();
                if (category.Topics == null)
                    category.Topics = new List<FTopic>();
                var top = new FTopic()
                {
                    Title = topic.Title
                };
                category.Topics.Add(top);
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();

            }

            return new TopicResp();
        }

        internal SubjectResp AddSubjectAction(SubjectData subject,int c_id,int t_id)
        {
            using (var db = new ForumContext())
            {
                Forum category;
                category = (from e in db.Forum where e.CategoryID == c_id select e).Include(d => d.Topics).FirstOrDefault();

                FTopic topic;
                topic =    (from e in category.Topics where e.TopicID == t_id select e).FirstOrDefault();

                if (topic.Subjects == null)
                    topic.Subjects = new List<FSubject>();
                var sub = new FSubject()
                {
                    Title = subject.Title,
                    Text = subject.Text
                };

                topic.Subjects.Add(sub);
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();

            }

            return new SubjectResp();
        }

        internal List<CategoryData> GetCategoryDataApi()
        {

            List<Forum> cat;
            var local = new List<CategoryData>();

            using (ForumContext db = new ForumContext())
            {
                cat = db.Forum.Include(d => d.Topics).ToList();
            }

            foreach (var c in cat)
            {
                var l = new CategoryData();
                var topic = new List<TopicData>();

                l.CategoryID = c.CategoryID;
                l.Title = c.Title;

                foreach (var t in c.Topics)
                {
                    var lt = new TopicData
                    {
                        TopicID = t.TopicID,
                        Title = t.Title
                    };
                    topic.Add(lt);
                }
                l.Topics = topic;
                local.Add(l);
            }
            return local;
        }

        internal TopicData GetTopicDataApi(int id)
        {
            var local = new TopicData {
                Subjects = new List<SubjectData>()
            };
            using (ForumContext db = new ForumContext())
            {
                
                FTopic topic;
                topic = (from e in db.Topic where e.TopicID == id select e).Include(d => d.Subjects).FirstOrDefault();

                local.TopicID = topic.TopicID;
                local.Title = topic.Title;
                foreach(var sub in topic.Subjects)
                {
                    var s = new SubjectData
                    {
                        SubjectID = sub.SubjectID,
                        Title = sub.Title,
                        Author = sub.Author,
                        Text = sub.Text

                    };
                    local.Subjects.Add(s);
                }
            }

            return local;
        }

        internal List<Image> GetGalerieDataApi()
        {
            List<IDbTable> img_list;
            var local = new List<Image>();
            using (ImageContext db = new ImageContext())
            {
                img_list = db.Images.ToList();
            }

            foreach(var img in img_list)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<IDbTable, Image>());
                var img_min = Mapper.Map<Image>(img);
                local.Add(img_min);
            }

            return local;
        }
    }
}
