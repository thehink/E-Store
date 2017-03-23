﻿using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public interface ICartRepository
    {
        void Add(Cart cart);
        Cart Find(int id);
        void Update(Cart cart);
        void Remove(int id);
    }
}