using AutoMapper;
using Lazy.Abp.Auditing.Logging;
using Lazy.Abp.Auditing.Security;
using Lazy.Abp.Files;
using Lazy.Abp.Files.Dto;
using Lazy.Abp.Identity;
using Lazy.Abp.IdentityServer.ApiResources;
using Lazy.Abp.IdentityServer.ApiScopes;
using Lazy.Abp.IdentityServer.Clients;
using Lazy.Abp.IdentityServer.Grants;
using Lazy.Abp.IdentityServer.IdentityResources;
using Lazy.Abp.TenantManagement;
using Volo.Abp.AuditLogging;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.ApiScopes;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.Grants;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.TenantManagement;

namespace Lazy.Abp
{
    public class LazyAbpApplicationAutoMapperProfile : Profile
    {
        public LazyAbpApplicationAutoMapperProfile()
        {
            CreateMap<IdentityClaimType, IdentityClaimTypeDto>()
                .MapExtraProperties();
            CreateMap<IdentityUserClaim, IdentityClaimDto>();
            CreateMap<IdentityRoleClaim, IdentityClaimDto>();

            CreateMap<IdentityUser, IdentityUserDto>()
                .MapExtraProperties();

            CreateMap<IdentityRole, IdentityRoleDto>()
                .MapExtraProperties();

            CreateMap<OrganizationUnit, OrganizationUnitDto>()
                .MapExtraProperties();

            CreateMap<AuditLogAction, AuditLogActionDto>()
                .MapExtraProperties();
            CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();
            CreateMap<EntityChange, EntityChangeDto>()
                .MapExtraProperties();
            CreateMap<AuditLog, AuditLogDto>()
                .MapExtraProperties();

            CreateMap<IdentitySecurityLog, SecurityLogDto>();

            CreateMap<ClientSecret, ClientSecretDto>();
            CreateMap<ClientScope, ClientScopeDto>();
            CreateMap<ClientGrantType, ClientGrantTypeDto>();
            CreateMap<ClientCorsOrigin, ClientCorsOriginDto>();
            CreateMap<ClientRedirectUri, ClientRedirectUriDto>();
            CreateMap<ClientPostLogoutRedirectUri, ClientPostLogoutRedirectUriDto>();
            CreateMap<ClientIdPRestriction, ClientIdPRestrictionDto>();
            CreateMap<ClientClaim, ClientClaimDto>();
            CreateMap<ClientProperty, ClientPropertyDto>();
            CreateMap<Client, ClientDto>();
            //.ForMember(dto => dto.AllowedCorsOrigins, map => map.MapFrom(client => client.AllowedCorsOrigins.Select(origin => origin.Origin).ToList()))
            //.ForMember(dto => dto.AllowedGrantTypes, map => map.MapFrom(client => client.AllowedGrantTypes.Select(grantType => grantType.GrantType).ToList()))
            //.ForMember(dto => dto.AllowedScopes, map => map.MapFrom(client => client.AllowedScopes.Select(scope => scope.Scope).ToList()))
            //.ForMember(dto => dto.IdentityProviderRestrictions, map => map.MapFrom(client => client.IdentityProviderRestrictions.Select(provider => provider.Provider).ToList()))
            //.ForMember(dto => dto.PostLogoutRedirectUris, map => map.MapFrom(client => client.PostLogoutRedirectUris.Select(uri => uri.PostLogoutRedirectUri).ToList()))
            //.ForMember(dto => dto.RedirectUris, map => map.MapFrom(client => client.RedirectUris.Select(uri => uri.RedirectUri).ToList()));

            // CreateMap<ApiSecret, ApiResourceSecretDto>();
            CreateMap<ApiScopeClaim, ApiScopeClaimDto>();
            CreateMap<ApiScopeProperty, ApiScopePropertyDto>()
                .ForMember(q => q.Id, op => op.MapFrom(x => x.ApiScopeId));
            CreateMap<ApiScope, ApiScopeDto>();

            CreateMap<ApiResourceProperty, ApiResourcePropertyDto>();
            CreateMap<ApiResourceSecret, ApiResourceSecretDto>();
            CreateMap<ApiResourceScope, ApiResourceScopeDto>();
            CreateMap<ApiResourceClaim, ApiResourceClaimDto>();
            CreateMap<ApiResource, ApiResourceDto>()
                .MapExtraProperties();

            CreateMap<IdentityResourceClaim, IdentityResourceClaimDto>();
            CreateMap<IdentityResourceProperty, IdentityResourcePropertyDto>();
            CreateMap<IdentityResource, IdentityResourceDto>()
                .MapExtraProperties();

            CreateMap<PersistedGrant, PersistedGrantDto>()
                .MapExtraProperties();

            CreateMap<TenantConnectionString, TenantConnectionStringDto>();

            CreateMap<Tenant, TenantManagement.TenantDto>()
                .MapExtraProperties();

            CreateMap<Media, MediaDto>()
                .MapExtraProperties();
        }
    }
}