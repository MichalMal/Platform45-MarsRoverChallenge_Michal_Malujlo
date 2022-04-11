using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Platform45_MarsRoverChallenge_Michal_Malujlo.Data;
using Platform45_MarsRoverChallenge_Michal_Malujlo.Enums;
using Platform45_MarsRoverChallenge_Michal_Malujlo.Models;
using Platform45_MarsRoverChallenge_Michal_Malujlo.Models.ViewModels;
using System.Diagnostics;

namespace Platform45_MarsRoverChallenge_Michal_Malujlo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.Rovers?.ToListAsync());

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string RoverName)
        {

            var roverModel = new RoverModel();
            roverModel.RoverName = RoverName;
            roverModel.X_Position = new Random().Next(0, 10);
            roverModel.Y_Position = new Random().Next(0, 10);

            Array values = Enum.GetValues(typeof(BearingEnum));
            Random random = new Random();
            BearingEnum randomBearing = (BearingEnum)values.GetValue(random.Next(values.Length));

            roverModel.Bearing = randomBearing;

            if (ModelState.IsValid)
            {
                _context.Add(roverModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roverModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditRoverViewModel Instruction)
        {
            var rover = await _context.Rovers.FindAsync(Instruction.ID);

            if (rover == null)
            {
                return NotFound();
            }
            try
            {
                foreach (char a in Instruction.MovementString.ToUpper())
                {
                    switch (a)
                    {
                        case 'M':
                            if (rover.Bearing == BearingEnum.North)
                                rover.Y_Position += 1;
                            else if (rover.Bearing == BearingEnum.East)
                                rover.X_Position += 1;
                            else if (rover.Bearing == BearingEnum.South)
                                rover.Y_Position -= 1;
                            else if (rover.Bearing == BearingEnum.West)
                                rover.X_Position -= 1;
                            break;
                        case 'L':
                            if (rover.Bearing == BearingEnum.North)
                                rover.Bearing = BearingEnum.West;
                            else if (rover.Bearing == BearingEnum.East)
                                rover.Bearing = BearingEnum.North;
                            else if (rover.Bearing == BearingEnum.South)
                                rover.Bearing = BearingEnum.East;
                            else if (rover.Bearing == BearingEnum.West)
                                rover.Bearing = BearingEnum.South;


                            break;
                        case 'R':
                            if (rover.Bearing == BearingEnum.North)
                                rover.Bearing = BearingEnum.East;
                            else if (rover.Bearing == BearingEnum.East)
                                rover.Bearing = BearingEnum.South;
                            else if (rover.Bearing == BearingEnum.South)
                                rover.Bearing = BearingEnum.West;
                            else if (rover.Bearing == BearingEnum.West)
                                rover.Bearing = BearingEnum.North;
                            break;
                        default:
                            // code block
                            break;
                    }

                }

                if (rover.X_Position < 0 || rover.Y_Position < 0 || rover.X_Position > 10 || rover.Y_Position > 10)
                {
                    _context.Rovers.Remove(rover);
                }
                else
                {
                    _context.Update(rover);
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoverExists(rover.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roverModel = await _context.Rovers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (roverModel == null)
            {
                return NotFound();
            }

            return View(roverModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roverModel = await _context.Rovers.FindAsync(id);
            _context.Rovers.Remove(roverModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private bool RoverExists(int id)
        {
            return _context.Rovers.Any(e => e.ID == id);
        }
    }
}