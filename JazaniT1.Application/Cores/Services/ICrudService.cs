namespace Jazani.Application.Cores.Services;
public interface ICrudService<TDto, TSaveDto, ID> :
    IQueryService<TDto,ID>,
    ISaveService<TDto,TSaveDto,ID>,
    IDisabledService<TDto,ID>
{
}
