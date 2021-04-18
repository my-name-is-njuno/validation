using System;
using System.Collections.Generic;
using System.Text;
using validation4.states.nav;
using validation4.viewmodels;

namespace validation4.factory
{
    public class VmFactory : IVmFactory
    {

        private readonly CreateVM<HomeVM> _createHVM;
        private readonly CreateVM<ProviderVM> _createPVM;
        private readonly CreateVM<DeliveryVM> _createDVM;
        private readonly CreateVM<RegisterVM> _createRVM;
        private readonly CreateVM<LoginVM> _createLVM;
        private readonly CreateVM<ShowProviderVM> _createSPVM;


        public VmFactory(CreateVM<HomeVM> createHVM, CreateVM<ProviderVM> createPVM, CreateVM<DeliveryVM> createDVM, CreateVM<RegisterVM> createRVM, CreateVM<LoginVM> createLVM, CreateVM<ShowProviderVM> createSPVM)
        {
            _createHVM = createHVM;
            _createPVM = createPVM;
            _createDVM = createDVM;
            _createRVM = createRVM;
            _createLVM = createLVM;
            _createSPVM = createSPVM;
        }

        public BaseVM CreateViewModel(ViewType vt)
        {
            switch (vt)
            {
                case ViewType.Home:
                    return _createHVM();
                case ViewType.Provider:
                    return _createPVM();
                case ViewType.Delivery:
                    return _createDVM();
                case ViewType.Login:
                    return _createLVM();
                case ViewType.Register:
                    return _createRVM();
                case ViewType.ShowProvider:
                    return _createSPVM();
                default:
                    throw new Exception();
            }
        }
    }
}
