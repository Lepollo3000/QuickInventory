﻿using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Services.Application;
using QUICK_INVENTORY.Domain;
using QUICK_INVENTORY.Shared.Models;
using QUICK_INVENTORY.Shared.Models.Requests;
using QUICK_INVENTORY.Shared.Models.TableModels;

namespace QUICK_INVENTORY.Helpers.Services.Application;

public class ProductoRegistrosService(IApplicationRepositories repositories) : IProductoRegistrosService
{
    private readonly IApplicationRepositories _repositories = repositories;

    public async Task<ProductoRegistro> InsertarProductoRegistro(ProductoMovimientoCreateRequest createRequest, IdentidadUsuario usuario)
    {
        int folio = await _repositories
            .ProductoRegistros.ConsultarFolio(
                createRequest: createRequest);

        var productoRegistro =
            new ProductoRegistro(
                createRequest: createRequest,
                folio: folio,
                usuario: usuario);

        _repositories.General.Context.Add(productoRegistro);

        return productoRegistro;
    }

    public async Task<ProductoRegistroTableModel> ConsultarProductoRegistros()
    {
        return new("", default, EnumRegistroTipo.Salida);
    }
}