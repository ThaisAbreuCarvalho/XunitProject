using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDomain.DTO
{
    public class Result<T>
    {
        public List<string> ErrorMessages { get; set; } = new List<string>();
        public virtual bool Sucess => !ErrorMessages.Any();

        public T Response { get; set; }
    }
}
