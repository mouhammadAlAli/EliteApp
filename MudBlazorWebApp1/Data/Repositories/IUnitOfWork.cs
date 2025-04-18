﻿namespace MudBlazorWebApp1.Data.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
internal class UnitOfWork : IUnitOfWork, IDisposable
{
    private bool _disposed;
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
    /// <summary>
    /// IDisposable
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


    /// <summary>
    /// custom dispose
    /// </summary>
    /// <param name="disposing"></param>

    protected void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}
