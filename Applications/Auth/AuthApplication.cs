using BookApi.Requests.Auth;
using BookApi.Repositories.User;
using BookApi.Repositories.Role;
using BookApi.Repositories.Permission;
using BookApi.Repositories.RolePermission;
using System.Collections.Generic;
using BookApi.Repositories.UserRole;
using BookApi.Exceptions;
using BookApi.Repositories.Auth;
using System;
using System.Linq;

namespace BookApi.Applications.Auth
{
    public class AuthApplication
    {
        private UserRoleQueryRepository userRoleQueryRepository;
        private UserQueryRepository userQueryRepository;
        private PermissionQueryRepository permissionQueryRepository;
        private RoleQueryRepository roleQueryRepository;
        private RolePermissionQueryRepository rolePermissionQueryRepository;

        public AuthApplication()
        {
            this.userRoleQueryRepository = new UserRoleQueryRepository();
            this.roleQueryRepository = new RoleQueryRepository();
            this.rolePermissionQueryRepository = new RolePermissionQueryRepository();
            this.permissionQueryRepository = new PermissionQueryRepository();
            this.userQueryRepository = new UserQueryRepository();
        }

        public AuthRepository SignInFromAPI(AuthSignIn authSignIn)
        {
            UserRepository userRepo = this.userQueryRepository.FindByEmail(authSignIn.Email);
            if (userRepo.Email == null)
            {
                throw (new DataNotFoundException("Email"));
            }

            DateTime expiredAt = DateTime.UtcNow.AddYears(1);
            return new AuthRepository()
            {
                ExpiredAt = expiredAt,
                Token = AuthUtility.GenerateJwtToken(userRepo.Id)
            };
        }
        public bool ValidateToken(string token)
        {
            long userId = AuthUtility.ValidateJwtToken(token);
            if (userId == 0)
            {
                return false;
            }

            Global.UserId = userId;
            return true;
        }
        public bool IsUserHaveRole(long userId, string role)
        {
            List<UserRoleRepository> userRoles = this.userRoleQueryRepository.FindByUserId(userId);
            long[] roleIds = userRoles.Select(userRole => userRole.Id).ToArray();
            return this.roleQueryRepository.IsExistsByNameAndIds(role, roleIds);
        }
        public bool IsRoleHavePermission(string role, string permission)
        {
            RoleRepository roleRepository = this.roleQueryRepository.FindByName(role);
            PermissionRepository permissionRepository = this.permissionQueryRepository.FindByName(permission);
            long roleId = roleRepository.Id;
            long permissionId = permissionRepository.Id;

            RolePermissionRepository rolePermissionRepository = this.rolePermissionQueryRepository.FindByRoleAndPermission(roleId, permissionId);
            return rolePermissionRepository.Id != 0;
        }
    }
}