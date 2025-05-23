﻿using SecureTaskAPI.DTOs;
using SecureTaskAPI.Models;

namespace SecureTaskAPI.Interfaces
{
    public interface IGetAPI
    {
        Task<GetDTO?> GetAPI(string apiName);
    }
}
