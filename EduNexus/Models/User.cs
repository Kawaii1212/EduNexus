using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class User
{
    public long Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public string Role { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public string? Phone { get; set; }

    public int FailedLoginCount { get; set; }

    public DateTimeOffset? LockedUntil { get; set; }

    public long? CreatedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }

    public virtual ICollection<AiQuotum> AiQuota { get; set; } = new List<AiQuotum>();

    public virtual ICollection<AiRequest> AiRequests { get; set; } = new List<AiRequest>();

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<Class> ClassCreatedByNavigations { get; set; } = new List<Class>();

    public virtual ICollection<ClassMaterial> ClassMaterials { get; set; } = new List<ClassMaterial>();

    public virtual ICollection<Class> ClassTeachers { get; set; } = new List<Class>();

    public virtual ICollection<CourseContentVersion> CourseContentVersions { get; set; } = new List<CourseContentVersion>();

    public virtual ICollection<CourseGroupMember> CourseGroupMemberAssignedByNavigations { get; set; } = new List<CourseGroupMember>();

    public virtual ICollection<CourseGroupMember> CourseGroupMemberUsers { get; set; } = new List<CourseGroupMember>();

    public virtual ICollection<CourseGroup> CourseGroups { get; set; } = new List<CourseGroup>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<FlashcardDeck> FlashcardDecks { get; set; } = new List<FlashcardDeck>();

    public virtual ICollection<FlashcardReviewLog> FlashcardReviewLogs { get; set; } = new List<FlashcardReviewLog>();

    public virtual ICollection<User> InverseCreatedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<KnowledgeGapAnalysis> KnowledgeGapAnalyses { get; set; } = new List<KnowledgeGapAnalysis>();

    public virtual ICollection<LearningProgress> LearningProgresses { get; set; } = new List<LearningProgress>();

    public virtual ICollection<LessonViewEvent> LessonViewEvents { get; set; } = new List<LessonViewEvent>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<LoginHistory> LoginHistories { get; set; } = new List<LoginHistory>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Question> QuestionApprovedByNavigations { get; set; } = new List<Question>();

    public virtual ICollection<Question> QuestionCreatedByNavigations { get; set; } = new List<Question>();

    public virtual ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();

    public virtual ICollection<RefundRequest> RefundRequestReviewedByNavigations { get; set; } = new List<RefundRequest>();

    public virtual ICollection<RefundRequest> RefundRequestStudents { get; set; } = new List<RefundRequest>();

    public virtual ICollection<Submission> SubmissionGradedByNavigations { get; set; } = new List<Submission>();

    public virtual ICollection<Submission> SubmissionStudents { get; set; } = new List<Submission>();

    public virtual ICollection<SubscriptionPackage> SubscriptionPackages { get; set; } = new List<SubscriptionPackage>();

    public virtual ICollection<SystemSetting> SystemSettings { get; set; } = new List<SystemSetting>();

    public virtual ICollection<UserOauthIdentity> UserOauthIdentities { get; set; } = new List<UserOauthIdentity>();

    public virtual ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();
}
