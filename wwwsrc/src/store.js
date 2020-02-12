import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    userKeeps: []
  },
  mutations: {
    setResource(state, payload) {
      state[payload.resource] = payload.data;
    }
  },
  actions: {
    // #region -- AUTH --
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    // #endregion
    // #region -- KEEPS --
    async getKeeps({ commit, dispatch }) {
      let res1 = await api.get("keeps");
      commit("setResource", { resource: "publicKeeps", data: res1.data });
      let res2 = await api.get("keeps/user");
      commit("setResource", { resource: "userKeeps", data: res2.data });
    },
    async createKeep({ commit, dispatch }, newKeep) {
      let res = await api.post("keeps", newKeep);
      dispatch("getKeeps");
    }
    // #endregion
  }
});
