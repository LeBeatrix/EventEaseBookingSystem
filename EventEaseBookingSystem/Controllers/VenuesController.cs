using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventEaseBookingSystem.Data;
using EventEaseBookingSystem.Models;
using EventEaseBookingSystem.Services;
using Microsoft.AspNetCore.Http;

namespace EventEaseBookingSystem.Controllers
{
    public class VenuesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly BlobService _blobService;

        public VenuesController(ApplicationDbContext context, BlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        // GET: Venues
        public async Task<IActionResult> Index(
    string searchString,
    bool? availableOnly)
        {
            var venues = _context.Venues.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                venues = venues.Where(v =>
                    v.VenueName.Contains(searchString) ||
                    v.Location.Contains(searchString));
            }

            if (availableOnly == true)
            {
                venues = venues.Where(v => v.IsAvailable);
            }

            return View(await venues.ToListAsync());
        }

        // GET: Venues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _context.Venues
                .FirstOrDefaultAsync(m => m.VenueId == id);
            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        // GET: Venues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Venues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("VenueId,VenueName,Location,Capacity,ImageUrl,IsAvailable")] Venue venue,
            IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var allowedExtensions = new HashSet<string>
        {
            ".jpg",
            ".jpeg",
            ".png"
        };

                var extension = Path.GetExtension(imageFile.FileName)
                    .ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("imageFile",
                        "Only JPG and PNG images are allowed.");
                }
            }
            else
            {
                ModelState.AddModelError("imageFile",
                    "Please upload an image.");
            }

            if (!ModelState.IsValid)
            {
                return View(venue);
            }

            try
            {
                venue.ImageUrl =
                    await _blobService.UploadFileAsync(imageFile);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
                return View(venue);
            }

            _context.Add(venue);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Venues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _context.Venues.FindAsync(id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        // POST: Venues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("VenueId,VenueName,Location,Capacity,ImageUrl,IsAvailable")] Venue venue,
            IFormFile imageFile)
                {
                    if (id != venue.VenueId)
                    {
                        return NotFound();
                    }

                    var existingVenue = await _context.Venues
                        .AsNoTracking()
                        .FirstOrDefaultAsync(v => v.VenueId == id);

                    if (existingVenue == null)
                    {
                        return NotFound();
                    }

                    // If new image uploaded
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        var allowedExtensions = new HashSet<string>
                {
                    ".jpg",
                    ".jpeg",
                    ".png"
                };

                        var extension = Path.GetExtension(imageFile.FileName)
                            .ToLowerInvariant();

                        if (!allowedExtensions.Contains(extension))
                        {
                            ModelState.AddModelError("imageFile",
                                "Only JPG and PNG images are allowed.");
                        }
                    }

                    if (!ModelState.IsValid)
                    {
                        venue.ImageUrl = existingVenue.ImageUrl;
                        return View(venue);
                    }

                    if (imageFile != null && imageFile.Length > 0)
                    {
                        // Delete old image from Blob Storage
                        if (!string.IsNullOrEmpty(existingVenue.ImageUrl))
                        {
                            await _blobService.DeleteFileAsync(existingVenue.ImageUrl);
                        }

                        // Upload new image
                        venue.ImageUrl = await _blobService.UploadFileAsync(imageFile);
                    }
                    else
                    {
                        // Keep existing image
                        venue.ImageUrl = existingVenue.ImageUrl;
                    }

                    try
                    {
                        _context.Update(venue);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VenueExists(venue.VenueId))
                        {
                            return NotFound();
                        }

                        throw;
                    }

                    return RedirectToAction(nameof(Index));
                }

        // GET: Venues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _context.Venues
                .FirstOrDefaultAsync(m => m.VenueId == id);
            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venue = await _context.Venues.FindAsync(id);

            // CHECK IF VENUE HAS BOOKINGS
            bool hasBookings = await _context.Bookings
                .AnyAsync(b => b.VenueId == id);

            if (hasBookings)
            {
                TempData["ErrorMessage"] =
                    "Cannot delete this venue because it has active bookings.";

                return RedirectToAction(nameof(Index));
            }

            if (venue != null)
            {
                //Delete image from blob storage
                if (!string.IsNullOrEmpty(venue.ImageUrl))
                {
                    await _blobService.DeleteFileAsync(venue.ImageUrl);
                }

                _context.Venues.Remove(venue);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VenueExists(int id)
        {
            return _context.Venues.Any(e => e.VenueId == id);
        }
    }
}
