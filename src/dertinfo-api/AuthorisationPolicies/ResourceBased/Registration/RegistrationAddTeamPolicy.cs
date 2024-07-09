﻿using DertInfo.Api.AuthorisationPolicies.Base;
using DertInfo.CrossCutting.Configuration;
using DertInfo.Models.Database;
using DertInfo.Models.System.Enumerations;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace DertInfo.Api.AuthorisationPolicies.ResourceBased
{
    public static class RegistrationAddTeamPolicy
    {
        public static string PolicyName { get { return "RegistrationAddTeamPolicy"; } }
    }

    public class RegistrationAddTeamRequirement : IClaimRequirement
    {
    }

    public class RegistrationAddTeamHandler : ResourceClaimHandler<RegistrationAddTeamRequirement, Registration>
    {
        public RegistrationAddTeamHandler(IDertInfoConfiguration configuration) : base(configuration)
        { }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RegistrationAddTeamRequirement requirement, Registration resource)
        {
            var hasGroupAdminClaimForRegistration = this.TestClaim(context.User, "https://dertinfo.co.uk/groupadmin", resource.GroupId);
            var hasEventAdminClaimForRegistration = this.TestClaim(context.User, "https://dertinfo.co.uk/eventadmin", resource.EventId);
            var hasSuperAdminClaim = this.TestClaim(context.User, "https://dertinfo.co.uk/superadmin", true);

            if (hasSuperAdminClaim)
            {
                context.Succeed(requirement);
            }

            if (hasEventAdminClaimForRegistration)
            {
                // Allow Edits To Event Admin                
                if (
                    resource.FlowState == RegistrationFlowState.New ||
                    resource.FlowState == RegistrationFlowState.Submitted ||
                    resource.FlowState == RegistrationFlowState.Confirmed 
                    )
                {
                    context.Succeed(requirement);
                }
            }

            if (hasGroupAdminClaimForRegistration)
            {
                // Allow Edits To Group Admin if is state new or submitted. 
                if (
                    resource.FlowState == RegistrationFlowState.New ||
                    resource.FlowState == RegistrationFlowState.Submitted
                    )
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
