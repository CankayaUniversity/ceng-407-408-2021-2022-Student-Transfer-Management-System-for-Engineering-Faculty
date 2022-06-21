﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Responses
{
    public class StudentCourseResponse
    {
        public int Id { get; set; }
        public string TakenCourseCode { get; set; }
        public string EquivalentCourseCode { get; set; }
        public string TakenCouseCredit { get; set; }
        public string EquivalentCourseCredit { get; set; }
        public string TakenCourseGrade { get; set; }
        public string EquivalentCourseGrade { get; set; }
        public bool Status { get; set; }
        public int StudentId { get; set; }

        public string Username { get; set; }

        public string StatusValue { get; set; }
    }
}
