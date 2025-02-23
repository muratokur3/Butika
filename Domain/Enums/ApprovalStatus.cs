using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums;

public enum ApprovalStatus
{
    PendingEmailVerification = 0, // E-posta onayı bekleniyor
    EmailVerified = 1, // E-posta onaylandı ama profil tamamlanmadı
    ProfileCompleted = 2, // Profil tamamlandı ama admin onayı bekliyor
    Approved = 3, // Admin tarafından onaylandı ve yayında
    Rejected = 4 // Admin tarafından reddedildi
}
