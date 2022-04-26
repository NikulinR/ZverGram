using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZverGram.Common.Exceptions;
using ZverGram.Common.Validator;
using ZverGram.Db.Context;
using ZverGram.Db.Entities;
using ZverGram.ExhibitionService.Models;

namespace ZverGram.ExhibitionService
{
    public class ExhibitionService : IExhibitionService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<AddExhibitionModel> addValidator;
        private readonly IModelValidator<UpdateExhibitionModel> updateValidator;

        public ExhibitionService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper, IModelValidator<AddExhibitionModel> addValidator, IModelValidator<UpdateExhibitionModel> updateValidator)
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.addValidator = addValidator;
            this.updateValidator = updateValidator;
        }

        public async Task<IEnumerable<ExhibitionModel>> GetExhibitions(int offset = 0, int limit = 100)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var exhibitions = context.Exhibitions.Include(x => x.Category).AsQueryable();
            exhibitions = exhibitions.Skip(Math.Max(offset, 0)).Take(Math.Min(limit, 1000));

            var data = (await exhibitions.ToListAsync()).Select(exhibition => mapper.Map<ExhibitionModel>(exhibition));

            return data;
        }

        public async Task<ExhibitionModel> GetExhibition(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var exhibition = await context.Exhibitions.Include(x => x.Category).AsQueryable().FirstOrDefaultAsync(x => x.Id.Equals(id));
            var data = mapper.Map<ExhibitionModel>(exhibition);

            return data;
        }

        public async Task<ExhibitionModel> AddExhibition(AddExhibitionModel model)
        {
            addValidator.Check(model);
            using var context = await contextFactory.CreateDbContextAsync();

            var exhibition = mapper.Map<Exhibition>(model);
            await context.Exhibitions.AddAsync(exhibition);
            context.SaveChanges();

            return mapper.Map<ExhibitionModel>(exhibition);
        }

        public async Task UpdateExhibition(int id, UpdateExhibitionModel model)
        {
            updateValidator.Check(model);
            using var context = await contextFactory.CreateDbContextAsync();

            var exhibition = context.Exhibitions.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new dbException($"Not found exhibition with id = {id}");
            exhibition = mapper.Map(model, exhibition);
            
            context.Exhibitions.Update(exhibition);
            context.SaveChanges();
        }

        public async Task DeleteExhibition(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var exhibition = context.Exhibitions.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new dbException($"Not found exhibition with id = {id}");
            
            context.Remove(exhibition);
            context.SaveChanges();
        }
    }
}
