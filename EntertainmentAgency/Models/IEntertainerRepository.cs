using System.Collections.Generic;
using EntertainmentAgency.Models;

public interface IEntertainerRepository
{
    IEnumerable<Entertainer> GetAllEntertainers();
    Entertainer GetEntertainerById(int entertainerId);
    void AddEntertainer(Entertainer entertainer);
    void UpdateEntertainer(Entertainer entertainer);
    void DeleteEntertainer(int entertainerId);
}
