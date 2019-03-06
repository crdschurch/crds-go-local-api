using System;
using System.Collections.Generic;
using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Tests.Helpers
{
  public class ProjectDataHelpers
  {
    public static List<MpProject> MockProjects()
    {
      return new List<MpProject>
      {
        new MpProject
        {
          ProjectId = 1,
          ProjectName = "Test Project 1",
          ProjectDescription = "Do Work",
          ProjectStatusId = 1,
          OrgName = "Test Org",
          ProjectType = "Gardening",
          ProjectTypeMinAge = 2,
          ProjectAgeException = null,
          CrdsSite = "Oakley",
          MinVols = 10,
          MaxVols = 20,
          Address1 = "123 Sesame St.",
          Address2 = "",
          AddressCity = "Cincinnati",
          AddressState = "OH",
          AddressZip = "12345",
          AddressLat = 0.0,
          AddressLong = 0.0,
          StartDate = new DateTime(2019, 05, 03),
          EndDate = new DateTime(2019, 05, 03),
          GroupId = 1234
        },
        new MpProject
        {
          ProjectId = 2,
          ProjectName = "Test Project 2",
          ProjectDescription = "Do Different Work",
          ProjectStatusId = 1,
          OrgName = "Test Org",
          ProjectType = "Construction",
          ProjectTypeMinAge = 18,
          ProjectAgeException = null,
          CrdsSite = "Oakley",
          MinVols = 10,
          MaxVols = 20,
          Address1 = "123 Sesame St.",
          Address2 = "",
          AddressCity = "Cincinnati",
          AddressState = "OH",
          AddressZip = "12345",
          AddressLat = 0.0,
          AddressLong = 0.0,
          StartDate = new DateTime(2019, 05, 03),
          EndDate = new DateTime(2019, 05, 03),
          GroupId = 5678
        }

      };
    }

    public static List<GroupCount> MockProjectVolCounts()
    {
      return new List<GroupCount>();
    }

    public static List<ProjectLeaders> MockProjectLeaders()
    {
      return new List<ProjectLeaders>();
    }
  }
}
