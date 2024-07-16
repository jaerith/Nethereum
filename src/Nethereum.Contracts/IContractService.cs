﻿using Nethereum.ABI.Model;
using Nethereum.Contracts.ContractHandlers;
using System;
using System.Collections.Generic;

namespace Nethereum.Contracts
{
    public interface IContractService
    {
        string ContractAddress { get; }
        ContractHandler ContractHandler { get; }

        SmartContractCustomErrorRevertExceptionErrorABI FindCustomErrorException(SmartContractCustomErrorRevertException exception);
        List<ErrorABI> GetAllErrorABIs();
        string[] GetAllErrorsSignatures();
        List<Type> GetAllErrorTypes();
        List<EventABI> GetAllEventABIs();
        string[] GetAllEventsSignatures();
        List<Type> GetAllEventTypes();
        List<FunctionABI> GetAllFunctionABIs();
        string[] GetAllFunctionSignatures();
        List<Type> GetAllFunctionTypes();
        void HandleCustomErrorException(SmartContractCustomErrorRevertException exception);
    }
}