using System.Collections;
using System.Collections.Generic;

namespace featherSample
{
    public interface ITodoService
    {
        IList<Todo> GetAll();
    }
}