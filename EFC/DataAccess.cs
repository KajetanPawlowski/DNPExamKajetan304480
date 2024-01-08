using EFC.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AppContext = EFC.AppContext;

public class DataAccess
{
    private AppContext _context;
    public DataAccess()
    {
        _context = new AppContext();
    }
    
    //all methods should use the _context here to access the data - out of time to write this
}