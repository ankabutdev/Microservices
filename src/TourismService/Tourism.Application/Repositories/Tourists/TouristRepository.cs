using Newtonsoft.Json;
using Tourism.Application.Interfaces.Tourits;
using Tourism.Domain.Entities.Tourists;

public class TouristRepository : ITouristRepository
{
    private string _filePath = "tourists.json";

    public async ValueTask<long> CountAsync()
    {
        var tourists = await ReadFromFile();
        return tourists.LongCount();
    }

    public async ValueTask<long> CreateAsync(Tourist entity)
    {
        var tourists = await ReadFromFile();
        entity.Id = tourists.Any() ? tourists.Max(t => t.Id) + 1 : 1;
        tourists.Add(entity);
        await WriteToFile(tourists);
        return entity.Id;
    }

    public async ValueTask<long> DeleteAsync(long id)
    {
        var tourists = await ReadFromFile();
        var tourist = tourists.FirstOrDefault(x => x.Id == id);

        if (tourist == null)
            return 0;

        tourists.Remove(tourist);
        await WriteToFile(tourists);
        return id;
    }

    public async ValueTask<IEnumerable<Tourist>> GetAllAsync()
    {
        return await ReadFromFile();
    }

    public async ValueTask<Tourist> GetByIdAsync(long id)
    {
        var tourists = await ReadFromFile();
        return tourists.FirstOrDefault(x => x.Id == id);
    }

    public async ValueTask<long> UpdateAsync(Tourist entity)
    {
        var tourists = await ReadFromFile();
        var existingTourist = tourists.FirstOrDefault(x => x.Id == entity.Id);

        if (existingTourist != null)
        {
            existingTourist.FirstName = entity.FirstName;
            existingTourist.LastName = entity.LastName;
            existingTourist.PhoneNumber = entity.PhoneNumber;
            existingTourist.PassportSeriaNumber = entity.PassportSeriaNumber;
        }

        await WriteToFile(tourists);
        return entity.Id;
    }

    private async ValueTask<List<Tourist>> ReadFromFile()
    {
        if (File.Exists(_filePath))
        {
            var json = await File.ReadAllTextAsync(_filePath);
            return JsonConvert.DeserializeObject<List<Tourist>>(json);
        }

        return new List<Tourist>();
    }

    private async ValueTask WriteToFile(List<Tourist> tourists)
    {
        var json = JsonConvert.SerializeObject(tourists, Newtonsoft.Json.Formatting.Indented);
        await File.WriteAllTextAsync(_filePath, json);
    }
}
