using MediatR;
using TranslationManagement.Business.Dto;

namespace TranslationManagement.Business;

public record AddTranslator(AddTranslatorDto Data) : IRequest<int>;
public record UpdateTranslatorStatus(int TranslatorId, TranslatorStatusDto Status) : IRequest;
public record AddJob(AddJobDto Data) : IRequest<int>;
public record UpdateJobStatus(UpdateJobStatusDto Data) : IRequest;
