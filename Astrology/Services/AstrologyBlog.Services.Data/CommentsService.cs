﻿using AstrologyBlog.Data.Common.Repositories;
using AstrologyBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrologyBlog.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task Create(int articleId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                ArticleId = articleId,
                ParentId = parentId,
                Content = content,
                UserId = userId,
            };
            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public bool IsCommentInArticle(int commentId, int articleId)
        {
            var commentArticleId = this.commentsRepository.All()
                .Where(x => x.Id == commentId)
                .Select(x => x.ArticleId)
                .FirstOrDefault();

            var isCommentInArticle = commentArticleId == articleId;
            return isCommentInArticle;
        }
    }
}
