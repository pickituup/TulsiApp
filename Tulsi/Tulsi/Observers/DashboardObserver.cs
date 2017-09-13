using System;
using Tulsi.Observers.DashboardArgs;

namespace Tulsi.Observers {
    public class DashboardObserver {

        public event EventHandler<HideAmountArgs> HideAmount = delegate { };

        public event EventHandler<VisibleBuyerSummaryArgs> VisibleBuyerSummary = delegate { };

        public event EventHandler<VisibleTodayRatesArgs> VisibleTodayRates = delegate { };

        public event EventHandler<VisibleLadaanArgs> VisibleLadaan = delegate { };

        public event EventHandler<VisibleColdStoireArgs> VisibleColdStoire = delegate { };

        public event EventHandler<VisibleTodayBalanceArgs> VisibleTodayBalance = delegate { };

        public void OnVisibleTodayBalance(bool isVisible) => VisibleTodayBalance(this, new VisibleTodayBalanceArgs() { IsVisible = isVisible });

        public void OnVisibleColdStoire(bool isVisible) {
            VisibleColdStoire(this, new VisibleColdStoireArgs() { IsVisible = isVisible });
        }

        public void OnVisibleLadaan(bool isVisible) {
            VisibleLadaan(this, new VisibleLadaanArgs() { IsVisible = isVisible });
        }

        public void OnVisibleTodayRates(bool isVisible) {
            VisibleTodayRates(this, new VisibleTodayRatesArgs() { IsVisible = isVisible });
        }

        public void OnVisibleBuyerSummary(bool isVisible) {
            VisibleBuyerSummary(this, new VisibleBuyerSummaryArgs() { IsVisible = isVisible });
        }

        public void OnHideAmount(bool isHide) {
            HideAmount(this, new HideAmountArgs() { IsHide = isHide });
        }
    }
}
