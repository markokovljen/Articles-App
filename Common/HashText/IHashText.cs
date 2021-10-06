using System;
using System.Collections.Generic;
using System.Text;

namespace Common.HashText
{
    public interface IHashText 
    {
        string HashPassword(string password);
    }
}
