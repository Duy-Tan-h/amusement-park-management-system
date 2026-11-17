using System.Net.Http.Json;
using DaiNamStaff.Models;

namespace DaiNamStaff.Services;

public class HousekeepingService
{
    private readonly HttpClient _http;
    public HousekeepingService(HttpClient http) => _http = http;

    public async Task<List<HousekeepingRoom>> GetUncleanedRooms()
    {
        try { return await _http.GetFromJsonAsync<List<HousekeepingRoom>>("/api/housekeeping/uncleaned") ?? new(); }
        catch { return new(); }
    }

    public async Task<bool> UpdateRoomStatus(int idPhong, string trangThai)
    {
        try
        {
            var res = await _http.PostAsJsonAsync("/api/housekeeping/update-status",
                new UpdateRoomStatusRequest(idPhong, trangThai));
            return res.IsSuccessStatusCode;
        }
        catch { return false; }
    }
}
