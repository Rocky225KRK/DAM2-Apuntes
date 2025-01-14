package org.rockyrk.fragments.ui.main;

import androidx.lifecycle.ViewModelProvider;

import android.content.Context;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import org.rockyrk.fragments.R;
import org.rockyrk.fragments.databinding.FragmentMainBinding;

public class HomeFragment extends Fragment {

    private MainViewModel mViewModel;

    private FragmentMainBinding binding;

    public static HomeFragment newInstance() {
        return new HomeFragment();
    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        // TODO: Use the ViewModel
    }

    @Override
    public void onAttach(@NonNull Context context) {
        super.onAttach(context);
        mViewModel = new ViewModelProvider(getActivity()).get(MainViewModel.class);
        mViewModel.getNames()[0]="SUPERMODIFIED!";
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        binding=FragmentMainBinding.inflate(inflater,container,false);
        return binding.getRoot();
        //return inflater.inflate(R.layout.fragment_main, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.btnDetail.setOnClickListener(view1 -> {
            getParentFragmentManager().beginTransaction()
                    .setCustomAnimations(
                            android.R.anim.slide_in_left,
                            android.R.anim.slide_out_right,
                            android.R.anim.slide_in_left,
                            android.R.anim.slide_out_right
                            )
                    .replace(R.id.container,DetailFragment.newInstance(400537))
                    .addToBackStack(null)
                    .commit();
        });
    }
}