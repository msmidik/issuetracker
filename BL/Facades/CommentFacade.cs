using AutoMapper;
using BL.Queries;
using BL.Repositories;
using Riganti.Utils.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;
using BL.DTOs;
using DAL.Entities;

namespace BL.Facades
{
    public class CommentFacade : AppFacadeBase
    {
        public CommentRepository CommentRepository { get; set; }
        public IssueRepository IssueRepository { get; set; }

        public CommentListQuery CommentListQuery { get; set; }


        protected IQuery<CommentDTO> CreateQuery(CommentFilter filter)
        {
            var query = CommentListQuery;
            query.Filter = filter;
            return query;
        }

        public List<CommentDTO> GetAllComments()
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery(new CommentFilter { }).Execute().ToList();
            }
        }

        public List<CommentDTO> GetCommentsByIds(int[] ids)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appComments = CommentRepository.GetByIds(ids);
                return Mapper.Map<List<CommentDTO>>(appComments);
            }
        }

        public void CreateComment(CommentDTO comment, int issueId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var dalComment = Mapper.Map<Comment>(comment);
                if (issueId > 0)
                {
                    dalComment.Issue = IssueRepository.GetById(issueId);
                }

                CommentRepository.Insert(dalComment);
                uow.Commit();
            }
        }

        public void UpdateComment(CommentDTO comment, int issueId = 0)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var appComment = CommentRepository.GetById(comment.Id);
                Mapper.Map(comment, appComment);
                if (issueId > 0)
                {
                    appComment.Issue = IssueRepository.GetById(issueId);
                }

                CommentRepository.Update(appComment);
                uow.Commit();
            }
        }

        public List<CommentDTO> GetCommentByIssue(int issueId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                return CreateQuery(new CommentFilter { IssueId = issueId }).Execute().ToList();
            }
        }


    }
}
