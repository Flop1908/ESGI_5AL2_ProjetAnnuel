//
//  AnneViewController.m
//  Anne&DocTique
//
//  Created by Kapi on 15/05/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import "AnneViewController.h"

@implementation AnneViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
    UIButton * button = [UIButton buttonWithType:UIButtonTypeCustom];
    button.frame = CGRectMake(0, 0, 80, 35);
    [button setTitle:@"Sources" forState:UIControlStateNormal];
    [button setTitleColor:[UIColor redColor] forState:UIControlStateNormal];
    [button setTitleColor:[UIColor blueColor] forState:UIControlStateHighlighted];
    [button addTarget:self action:@selector(leftButtonTouch) forControlEvents:UIControlEventTouchUpInside];
    self.navigationItem.leftBarButtonItem = [[UIBarButtonItem alloc] initWithCustomView:button];
    
    typeof(self) bself = self;
    self.phSwipeHander = ^{
        [bself.airViewController showAirViewFromViewController:bself.navigationController complete:nil];
    };
}

- (void)leftButtonTouch
{
    [self.airViewController showAirViewFromViewController:self.navigationController complete:nil];
}

- (UILabel*)label
{
    if (!_label) {
        _label = [[UILabel alloc] initWithFrame:CGRectMake(0, 80, 320, 40)];
        _label.backgroundColor = [UIColor clearColor];
        _label.textAlignment = NSTextAlignmentCenter;
        _label.font = [UIFont boldSystemFontOfSize:16];
        _label.textColor = [UIColor redColor];
        [self.view addSubview:_label];
    }
    return _label;
}

@end
