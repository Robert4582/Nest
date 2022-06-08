using System.Collections.Generic;

public interface IDataFetcher<T>
{
    public List<T> Fetch(string dataName);
}