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
    public class DanhMucSanPhams_23TH0004Controller : Controller
    {
        private ThietBiNhaBep_23TH0004Entities db = new ThietBiNhaBep_23TH0004Entities();

        #region For every body
        public ActionResult MenuLists()
        {
            return View(db.DanhMucSanPhams.ToList());
        }
        #endregion

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.DanhMucSanPhams.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPhams.Find(id);
            if (danhMucSanPham == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSanPham);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDanhMuc,TenDanhMuc,TrangThai,NgayTao")] DanhMucSanPham danhMucSanPham)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucSanPhams.Add(danhMucSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhMucSanPham);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPhams.Find(id);
            if (danhMucSanPham == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSanPham);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDanhMuc,TenDanhMuc,TrangThai,NgayTao")] DanhMucSanPham danhMucSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMucSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhMucSanPham);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPhams.Find(id);
            if (danhMucSanPham == null)
            {
                return HttpNotFound();
            }
            return View(danhMucSanPham);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMucSanPham danhMucSanPham = db.DanhMucSanPhams.Find(id);
            db.DanhMucSanPhams.Remove(danhMucSanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
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
