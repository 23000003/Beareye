using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext context;
        
        public CommentRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await context.Comments.AddAsync(commentModel);
            await context.SaveChangesAsync();

            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if(commentModel == null)
            {
                return null;
            }

            context.Comments.Remove(commentModel);
            await context.SaveChangesAsync();

            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await context.Comments.Include(a => a.AppUserId).ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await context.Comments.Include(a => a.AppUserId).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existComment = await context.Comments.FindAsync(id);

            if(existComment == null){
                return null;
            }

            context.Entry(existComment).CurrentValues.SetValues(commentModel);

            await context.SaveChangesAsync();

            return existComment;
        }
        
    }
}