﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ThumbsApi.Contexts;
using ThumbsApi.Models;
using ThumbsApi.Services.Interfaces;

namespace ThumbsApi.Services
{
    public class ThumbsRepository : IThumbsRepository
    {
        private readonly Context _context;

        public ThumbsRepository(Context thumbContext)
        {
            _context = thumbContext;
        }

        public void Add(Thumb items)
        {
            _context.Thumbs
                         .Add(items);
        }

        public void Delete(Thumb thumb)
        {
            _context.Thumbs
                         .Remove(thumb);
        }

        public Task<Thumb> GetAsync(Expression<Func<Thumb, bool>> where)
        {
            return _context.Thumbs
                                .Where(where)
                                .FirstOrDefaultAsync();
        }

        public Task<List<Thumb>> GetManyAsync()
        {
            return _context.Thumbs
                              .ToListAsync();

        }

        public Task<List<Thumb>> GetManyAsync(Expression<Func<Thumb, bool>> where)
        {
            return _context.Thumbs
                                .Where(where)
                                .ToListAsync();
        }

        public Task<List<Thumb>> GetManyAsync<T>(Expression<Func<Thumb, bool>> where, Expression<Func<Thumb, T>> orderBy, int take)
        {
            return _context.Thumbs
                                .Where(where)
                                .OrderBy(orderBy)
                                .Take(take)
                                .ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Thumb thumb)
        {
            //not needed in this implementation
        }
    }
}
