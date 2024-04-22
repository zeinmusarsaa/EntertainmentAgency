using EntertainmentAgency.Models;
using System.Collections.Generic;
using System.Linq;

public class EFEntertainerRepository : IEntertainerRepository
{
    private readonly EntertainmentAgencyExampleContext context;

    public EFEntertainerRepository(EntertainmentAgencyExampleContext ctx)
    {
        context = ctx;
    }

    public IEnumerable<Entertainer> GetAllEntertainers()
    {
        return context.Entertainers.ToList() ?? new List<Entertainer>();
    }

    public Entertainer GetEntertainerById(int entertainerId)
    {
        return context.Entertainers
            .FirstOrDefault(e => e.EntertainerId == entertainerId);
    }

    public void AddEntertainer(Entertainer entertainer)
    {
        context.Entertainers.Add(entertainer);
        context.SaveChanges();
    }

    public void UpdateEntertainer(Entertainer entertainer)
    {
        context.Entertainers.Update(entertainer);
        context.SaveChanges();
    }

    public void DeleteEntertainer(int entertainerId)
    {
        var entertainer = context.Entertainers
            .FirstOrDefault(e => e.EntertainerId == entertainerId);
        if (entertainer != null)
        {
            context.Entertainers.Remove(entertainer);
            context.SaveChanges();
        }
    }
}

