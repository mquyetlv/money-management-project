﻿namespace money_management_service.Core
{
    public class BaseSearchCondition
    {
        public int Page { get; set; } = 0;

        public int Size { get; set; } = 10;
    }
}
