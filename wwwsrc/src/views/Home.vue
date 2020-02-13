<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col">
        <h1>Animal!</h1>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <div class="card-columns" v-if="publicKeeps.length > 0">
          <keep
            v-for="keep in publicKeeps"
            :key="keep.id"
            :keepData="keep"
          ></keep>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "../components/Keep";
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return (
        this.$store.state.publicKeeps || {
          title: "Loading..."
        }
      );
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    Keep
  }
};
</script>
