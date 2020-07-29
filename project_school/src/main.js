import Vue from 'vue'
import App from './App.vue'
import VueResources from 'vue-resource'
import router from './router'

Vue.config.productionTip = false
Vue.use(VueResources);
new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
