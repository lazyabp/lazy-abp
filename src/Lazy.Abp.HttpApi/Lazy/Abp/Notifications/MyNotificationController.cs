﻿using Lazy.Abp.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.Notifications
{
    [RemoteService(Name = LazyAbpServiceConsts.RemoteServiceName)]
    [Route("api/my-notifilers")]
    public class MyNotificationController : AbpController, IMyNotificationAppService
    {
        protected IMyNotificationAppService MyNotificationAppService { get; }

        public MyNotificationController(
            IMyNotificationAppService myNotificationAppService)
        {
            MyNotificationAppService = myNotificationAppService;
        }

        [HttpPost]
        public virtual async Task SendNofiterAsync(NotificationSendDto input)
        {
            await MyNotificationAppService.SendNofiterAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual async Task DeleteAsync(long id)
        {
            await MyNotificationAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("assignables")]
        public virtual async Task<ListResultDto<NotificationGroupDto>> GetAssignableNotifiersAsync()
        {
            return await MyNotificationAppService.GetAssignableNotifiersAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<NotificationInfo> GetAsync(long id)
        {
            return await MyNotificationAppService.GetAsync(id);
        }

        [HttpGet]
        public virtual async Task<PagedResultDto<NotificationInfo>> GetListAsync(UserNotificationGetByPagedDto input)
        {
            return await MyNotificationAppService.GetListAsync(input);
        }
    }
}
