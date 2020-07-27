import Vue from 'vue'
import App from './App.vue'
import VueResources from 'vue-resource'

Vue.config.productionTip = false
Vue.use(VueResources);
new Vue({
  render: h => h(App),
}).$mount('#app')
