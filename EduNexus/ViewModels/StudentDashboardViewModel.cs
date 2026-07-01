using System.Collections.Generic;

namespace EduNexus.ViewModels
{
    public class StudentDashboardViewModel
    {
        public string StudentName { get; set; } = "Student";
        public int CoursesInProgress { get; set; }
        public int AssignmentsDue { get; set; }
        public int TotalLearningHours { get; set; }
        public int CurrentStreak { get; set; }
        
        public OngoingCourseViewModel? LastAccessedCourse { get; set; }
        public List<OngoingCourseViewModel> OngoingCourses { get; set; } = new List<OngoingCourseViewModel>();
        public List<DeadlineViewModel> UpcomingDeadlines { get; set; } = new List<DeadlineViewModel>();
        public List<NotificationViewModel> RecentNotifications { get; set; } = new List<NotificationViewModel>();
    }

    public class DeadlineViewModel
    {
        public string Title { get; set; } = "";
        public string CourseName { get; set; } = "";
        public string Month { get; set; } = "";
        public string Day { get; set; } = "";
        public string DueInText { get; set; } = "";
        public bool IsWarning { get; set; }
        public bool IsDanger { get; set; }
    }

    public class NotificationViewModel
    {
        public string Content { get; set; } = "";
        public string TimeAgo { get; set; } = "";
        public string IconClass { get; set; } = "fa-bell";
        public string IconColorClass { get; set; } = "";
    }
}
