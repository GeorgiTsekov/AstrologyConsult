namespace AstrologyBlog.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class ArticlesCategoriesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<ArticlesCategory> dataRepository;

        public ArticlesCategoriesController(IDeletableEntityRepository<ArticlesCategory> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        // GET: Administration/ArticlesCategories
        public async Task<IActionResult> Index()
        {
            return this.View(await this.dataRepository.AllWithDeleted().ToListAsync());
        }

        // GET: Administration/ArticlesCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var articlesCategory = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articlesCategory == null)
            {
                return this.NotFound();
            }

            return this.View(articlesCategory);
        }

        // GET: Administration/ArticlesCategories/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/ArticlesCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] ArticlesCategory articlesCategory)
        {
            if (this.ModelState.IsValid)
            {
                await this.dataRepository.AddAsync(articlesCategory);
                await this.dataRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(articlesCategory);
        }

        // GET: Administration/ArticlesCategories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var articlesCategory = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            if (articlesCategory == null)
            {
                return this.NotFound();
            }

            return this.View(articlesCategory);
        }

        // POST: Administration/ArticlesCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] ArticlesCategory articlesCategory)
        {
            if (id != articlesCategory.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.dataRepository.Update(articlesCategory);
                    await this.dataRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ArticlesCategoryExists(articlesCategory.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(articlesCategory);
        }

        // GET: Administration/ArticlesCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var articlesCategory = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articlesCategory == null)
            {
                return this.NotFound();
            }

            return this.View(articlesCategory);
        }

        // POST: Administration/ArticlesCategories/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articlesCategory = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            this.dataRepository.Delete(articlesCategory);
            await this.dataRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ArticlesCategoryExists(int id)
        {
            return this.dataRepository.All().Any(e => e.Id == id);
        }
    }
}
