using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class UserRegisterDTO
{
    /// <summary>
    /// Имя
    /// </summary>
    [Required]
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required]
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Возраст
    /// </summary>
    [Required]
    public int Age { get; set; }

    /// <summary>
    /// Почта
    /// </summary>
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; set; } = default!;

    /// <summary>
    /// Пароль
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;
}