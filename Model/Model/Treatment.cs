﻿using System.Collections.Generic;

namespace Model
{
    public class Treatment
    {
        public int Id { get; set; }
        public List<DrugRecord> Drugs { get; set; }
    }
}