//
//  DetailViewController.h
//  Anne4Doctique
//
//  Created by Kapi on 21/06/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface DetailViewController : UIViewController

@property (strong, nonatomic) id detailItem;

@property (weak, nonatomic) IBOutlet UILabel *detailDescriptionLabel;
@end
