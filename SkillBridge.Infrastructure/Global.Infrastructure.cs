global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using SkillBridge.Domain.Entities;
global using SkillBridge.Infrastructure.Identity;

global using Microsoft.AspNetCore.Identity;
global using SkillBridge.Domain.Enums;

global using System.Reflection;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

global using System.Transactions;
global using SkillBridge.Application.Interfaces.Repositories;
global using SkillBridge.Application.Interfaces.UnitOfWork;
global using SkillBridge.Infrastructure.Data;
global using SkillBridge.Infrastructure.Repos;
global using System.Linq.Expressions;


global using System.Data;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using SkillBridge.Application.Dtos;
global using SkillBridge.Application.Dtos.Common;
global using SkillBridge.Application.Interfaces.Services;
global using SkillBridge.Application.ReturnObject;