//using System;
//using System.Collections.Generic;
//using System.Linq;
//using loginAPI.Models;

//namespace loginAPI.Data
//{
//    public class MockComments: IComment
//    {
//        private readonly CommentDbContext _context;
//      //  private readonly QandADBContext _qandADBContext; 

//        public MockComments(CommentDbContext context, QandADBContext qandADBContext)
//        {
//            _context = context;
//            _qandADBContext = qandADBContext; 
//        }

//        public Comment AcceptComment(int id)
//        {
//            var c = _context.Comments.FirstOrDefault(c => c.CommentId == id);
//            c.Accepted = true;
//            SaveChanges(); 
//            return c; 
//        }

//        public bool AddComment(Comment c)
//        {
//            try
//            {
//                _context.Comments.Add(c);
//                SaveChanges();  
//                return true;
//            }
//            catch(Exception)
//            {
//                return false;
//            }
//        }

//        public bool DeleteComment(int id)
//        {
//            var Comment = _context.Comments.FirstOrDefault(c => c.CommentId == id);
//            try
//            {
//                _context.Comments.Remove(Comment);
//                SaveChanges(); 
//                return true;
//            }
//            catch (Exception)
//            {
//                return false; 
//            }
//        }

//        public IEnumerable<Comment> GetAcceptedCommentsForAQ(int QId)
//        {
//            var c = _context.Comments.Where(c => (c.QuestionId == QId && c.Accepted == true));
//            return c.ToList(); 
//        }

//        public IEnumerable<Comment> GetAllComments()
//        {
//            return _context.Comments.ToList();  
//        }

//        public IEnumerable<CommentWithQ> GetAllPending()
//        {
//          var Pending =  _context.Comments.Where(c => c.Accepted == false);
//            List<CommentWithQ> result = new List<CommentWithQ>();
//            foreach ( Comment p in Pending)
//            {
//                var question = _qandADBContext.QandAs.FirstOrDefault(q => q.Id== p.QuestionId);
//                var commentWithQ = new CommentWithQ
//                {
//                    CommentId = p.CommentId,
//                    QuestionId = p.QuestionId,
//                    AddedBy = p.AddedBy,
//                    CommentBody = p.CommentBody,
//                    Accepted = p.Accepted,
//                    Counter = p.Counter,
//                    QuestionBody = question.Question
//                };
//                result.Add(commentWithQ); 
//            }
//          return result; 

//        }

//        public bool SaveChanges()
//        {
//            return (_context.SaveChanges() >= 0);
//        }
//    }
//}
