using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace FIleUploader.Controllers
{
    /// <summary>
    /// An object representation of a drive file or folder
    /// </summary>
    [DataContract]
    public class StorageObject 
    {
        /// <summary>
        /// File or folder identifier
        /// </summary>
        [DataMember]
        [Required(AllowEmptyStrings = false)]
        public string Id { get; set; }

        /// <summary>
        /// Path of the folder or file
        /// </summary>
        [DataMember]
        [Required(AllowEmptyStrings = false)]
        public string Path { get; set; }

        /// <summary>
        /// Name of the folder or file
        /// </summary>
        [DataMember]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        /// <summary>
        /// Identifier of the user who created the file or folder
        /// </summary>
        [DataMember]
        [Required]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Date of file/folder creation
        /// </summary>
        [DataMember]
        [Required]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// Identifier of the last user to modify the file or folder
        /// </summary>
        [DataMember]
        [Required]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Date of file/folder modification
        /// </summary>
        [DataMember]
        [Required]
        public DateTimeOffset UpdatedOn { get; set; }

        /// <summary>
        /// Type of storage object (file or folder)
        /// </summary>
        [DataMember]
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Size of the file in bytes
        /// </summary>
        [DataMember]
        public int? Size { get; set; }

        /// <summary>
        /// File status corresponding to virus scan status.
        /// (Active, Available, Checking, MalwareDetected, Failed)
        /// </summary>
        [DataMember]
        public string Status { get; set; }

        /// <summary>
        /// Detailed description describing any negative terminal state of file
        /// </summary>
        [DataMember]
        public string StatusDetail { get; set; }

        /// <inheritdoc />
        public StorageObject(string id, string path, string name, string createdBy, DateTimeOffset createdOn,
            string updatedBy, DateTimeOffset updatedOn, string type, string status = null, int? size = null,
            string statusDetail = null)
        {
            Id = id;
            Path = path;
            Name = name;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            UpdatedBy = updatedBy;
            UpdatedOn = updatedOn;
            Type = type;
            Size = size;
            Status = status;
            StatusDetail = statusDetail;
        }

      

        
    }

    
}
