﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL
{
    public sealed record RemoveByIdUserAndCompanyRLCommandResponse(
        string Message="Kullanıcı şirketten başarıyla çıkarıldı!");
}
