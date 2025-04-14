using System.Runtime.CompilerServices;
using API2.Dtos.Comment;
using API2.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API2.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto tocommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId
          
            };
        }
        public static Comment tocreatecomment(this CreateComment commentModel, int StockId)
        {
            return new Comment
            {
                Title = commentModel.Title,
                Content = commentModel.Content,
                StockId = StockId,
            };
        }
        public static Comment toUpdatcomment(this UpdateCommentDto commentModel)
        {
            return new Comment
            {
                Title = commentModel.Title,
                Content = commentModel.Content,
               
            };
        }
    }
}
