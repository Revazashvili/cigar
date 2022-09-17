using System.Collections;

namespace Cigar.Core.Models;

public record RequestHeaders : IEnumerable<RequestHeader>
{
    private readonly ICollection<RequestHeader> _headers;

    public RequestHeaders()
    {
        _headers = new List<RequestHeader>();
    }
    
    public RequestHeaders(ICollection<RequestHeader> headers)
    {
        _headers = headers;
    }
    
    public IEnumerator<RequestHeader> GetEnumerator() => _headers.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _headers.GetEnumerator();

    public void Add(RequestHeader header)
    {
        var existingHeader = _headers.FirstOrDefault(h => h.Key == header.Key);
        if (existingHeader != null)
            _headers.Remove(existingHeader);
        _headers.Add(header);
    }

    public void Clear() => _headers.Clear();

    public bool Contains(RequestHeader header) => _headers.Contains(header);

    public void CopyTo(RequestHeader[] headers, int arrayIndex) => _headers.CopyTo(headers,arrayIndex);

    public bool Remove(RequestHeader header) => _headers.Remove(header);

    public int Count => _headers.Count;
    
    public bool IsReadOnly => false;
}