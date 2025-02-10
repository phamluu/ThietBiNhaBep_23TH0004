using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThietBiNhaBep_23TH0004.Models;

namespace ThietBiNhaBep_23TH0004.Controllers
{
    public class SanPhams_23TH0004Controller : Controller
    {
        private ThietBiNhaBep_23TH0004Entities db = new ThietBiNhaBep_23TH0004Entities();

        #region For every body
        public ActionResult PartialList(string viewname)
        {
            var model = db.SanPhams;
            return View(viewname, model);
        }
        public ActionResult List(int CategoryId)
        {
            var dm = db.DanhMucSanPhams.Find(CategoryId);
            ViewBag.Title = dm.TenDanhMuc;
            var model = db.SanPhams.Where(x => x.MaDanhMuc == CategoryId);
            return View(model);
        }
        #endregion
        // GET: SanPhams_23TH0024
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.DanhMucSanPham).Include(s => s.HangSanPham);
            return View(sanPhams.ToList());
        }

        // GET: SanPhams_23TH0024/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams_23TH0024/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc");
            ViewBag.MaHang = new SelectList(db.HangSanPhams, "MaHang", "TenHang");
            return View();
        }

        // POST: SanPhams_23TH0024/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,TenSanPham,MoTa,Gia,GiaMoi,HinhAnh,MaHang,MaDanhMuc,NgayTao,TrangThai,SoLuong")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
            ViewBag.MaHang = new SelectList(db.HangSanPhams, "MaHang", "TenHang", sanPham.MaHang);
            return View(sanPham);
        }

        // GET: SanPhams_23TH0024/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
            ViewBag.MaHang = new SelectList(db.HangSanPhams, "MaHang", "TenHang", sanPham.MaHang);
            return View(sanPham);
        }

        // POST: SanPhams_23TH0024/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,TenSanPham,MoTa,Gia,GiaMoi,HinhAnh,MaHang,MaDanhMuc,NgayTao,TrangThai,SoLuong")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucSanPhams, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
            ViewBag.MaHang = new SelectList(db.HangSanPhams, "MaHang", "TenHang", sanPham.MaHang);
            return View(sanPham);
        }

        // GET: SanPhams_23TH0024/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams_23TH0024/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
