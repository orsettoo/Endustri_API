﻿namespace Endustri_API.Entity
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; } = false;  
         
        public string Message { get; set; } = string.Empty;

        public T Data { get; set; }
    }
}
