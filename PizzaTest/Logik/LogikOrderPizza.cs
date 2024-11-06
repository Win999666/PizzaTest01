using Microsoft.EntityFrameworkCore;
using PizzaTest.Data;
using PizzaTest.Models;

namespace PizzaTest.Logik;

public class LogikOrderPizza
{
    private readonly AppDbContext _appDbContext;
    public LogikOrderPizza(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<string> Add(OrderPizza order)
    {

        if (order == null) { return "неудачно"; }
        await _appDbContext.Orders.AddAsync(order);
        await _appDbContext.SaveChangesAsync();
        return "удачно";
    }
    public async Task<Response> DeleteOrder(int id)
    {

        var order = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
        if (order == null) return new Response()
        {
            Status = "неудачно"
        };
        _appDbContext.Orders.Remove(order);
        await _appDbContext.SaveChangesAsync();
        return new Response()
        {
            Vallu = order,
            Status = "удачно"
        };

    }
    public async Task<Response> DeleteOrderAsunc(int id)
    {
        var code = await _appDbContext.Orders.Where(x => x.Id == id).ExecuteDeleteAsync();
        return new Response { StatusCod = code };
    }
    public IQueryable<OrderPizza> GetOrders()
    {
        var result = _appDbContext.Orders.AsQueryable();
        return result;
    }
}
public class Response
{
    public int StatusCod { get; set; }
    public string Status { get; set; }
    public DateTime Data
    {
        get
        {
            return DateTime.Now;
        }
    }
    public object Vallu { get; set; }
}